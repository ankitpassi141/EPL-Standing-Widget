package md5a39d3b020147165ff7e4c9e37c888b38;


public class AppWidget
	extends android.appwidget.AppWidgetProvider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onUpdate:(Landroid/content/Context;Landroid/appwidget/AppWidgetManager;[I)V:GetOnUpdate_Landroid_content_Context_Landroid_appwidget_AppWidgetManager_arrayIHandler\n" +
			"";
		mono.android.Runtime.register ("FootballUpdateWidget.AppWidget, FootballUpdateWidget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AppWidget.class, __md_methods);
	}


	public AppWidget ()
	{
		super ();
		if (getClass () == AppWidget.class)
			mono.android.TypeManager.Activate ("FootballUpdateWidget.AppWidget, FootballUpdateWidget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onUpdate (android.content.Context p0, android.appwidget.AppWidgetManager p1, int[] p2)
	{
		n_onUpdate (p0, p1, p2);
	}

	private native void n_onUpdate (android.content.Context p0, android.appwidget.AppWidgetManager p1, int[] p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
