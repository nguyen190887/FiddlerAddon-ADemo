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
    private GptViewerControl _viewer;

    //#region IAutoTamper Members

    //public void AutoTamperRequestAfter(Session oSession)
    //{

    //}

    //public void AutoTamperRequestBefore(Session oSession)
    //{

    //}

    //public void AutoTamperResponseAfter(Session oSession)
    //{

    //}

    //public void AutoTamperResponseBefore(Session oSession)
    //{

    //}

    //public void OnBeforeReturningError(Session oSession)
    //{

    //}

    //#endregion

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
            LoadPage();
        }
    }

    private void LoadPage()
    {
        _viewer = new GptViewerControl();
        _page.Controls.Add(_viewer);
        _viewer.Dock = DockStyle.Fill;
    }

    #endregion
}
