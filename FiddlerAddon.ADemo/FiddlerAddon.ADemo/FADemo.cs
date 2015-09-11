using Fiddler;
using FiddlerAddon.ADemo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

[assembly: Fiddler.RequiredVersion("2.3.5.0")]
public class FADemo : IFiddlerExtension
{
    private TabPage _page;
    private GptViewer _viewer;
    private Session[] _sessions;

    private const string FIELD_DARTSITE = "iu";
    private const string FIELD_SIZE = "sz";
    private const string FIELD_SPONSORSHIP = "scp";
    private const string FIELD_CUSTPARAM = "cust_params";

    #region IFiddlerExtension Members

    // Called when Fiddler is shutting down
    public void OnBeforeUnload()
    {

    }

    // Called when Fiddler User Interface is fully available
    public void OnLoad()
    {
        // Create new tab in Fiddler
        _page = new TabPage("GPT Viewer");
        _page.ImageIndex = (int)Fiddler.SessionIcons.Document;

        FiddlerApplication.UI.tabsViews.TabPages.Add(_page);
        FiddlerApplication.UI.tabsViews.SelectedIndexChanged += tabsViews_SelectedIndexChanged;
    }

    void tabsViews_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!FiddlerApplication.isClosing && FiddlerApplication.UI.tabsViews.SelectedTab == _page)
        {
            FiddlerApplication.UI.tabsViews.SelectedIndexChanged -= tabsViews_SelectedIndexChanged;

            LoadPage();
        }
    }

    private void LoadPage()
    {
        _viewer = new GptViewer();
        _page.Controls.Add(_viewer);
        _viewer.Dock = DockStyle.Fill;

        FiddlerApplication.CalculateReport += FiddlerApplication_CalculateReport;

        _sessions = FiddlerApplication.UI.GetSelectedSessions();
        BindGptData();
    }

    void FiddlerApplication_CalculateReport(Session[] _arrSessions)
    {
        _sessions = _arrSessions;
        BindGptData();
    }

    private void BindGptData()
    {
        if (_sessions.Length > 0)
        {
            var session = _sessions[0];
            int questionIndex = session.PathAndQuery.IndexOf("?");
            if (questionIndex >= 0)
            {
                string qs = session.PathAndQuery.Substring(questionIndex + 1);
                var collection = Fiddler.Utilities.ParseQueryString(qs);

                // Extract data
                var gptRecord = new GptRecord();
                foreach (string key in collection)
                {
                    switch (key.ToLower())
                    {
                        case FIELD_DARTSITE:
                            gptRecord.DartSite = collection[key];
                            break;
                        case FIELD_SIZE:
                            gptRecord.Size = collection[key];
                            break;
                        case FIELD_SPONSORSHIP:
                            gptRecord.Sponsorship = collection[key];
                            break;
                        case FIELD_CUSTPARAM:
                            gptRecord.CustParams = collection[key];
                            break;
                    }
                }

                _viewer.DisplayData(gptRecord);
            }
        }
    }

    #endregion


    
}
