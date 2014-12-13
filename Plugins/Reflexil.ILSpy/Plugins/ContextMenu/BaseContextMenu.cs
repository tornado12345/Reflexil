﻿using System.Linq;
using ICSharpCode.ILSpy;
using ICSharpCode.TreeView;

namespace Reflexil.Plugins.ILSpy.ContextMenu
{
    internal abstract class BaseContextMenu : IContextMenuEntry
    {
	    protected abstract void Execute(SharpTreeNode node);
	    protected abstract bool IsVisible(SharpTreeNode node);

	    public bool IsEnabled(TextViewContext context)
	    {
		    return context.SelectedTreeNodes.Length == 1;
	    }

		public bool IsVisible(TextViewContext context)
		{
			return IsVisible(context.SelectedTreeNodes.FirstOrDefault());
		}

	    public void Execute(TextViewContext context)
	    {
		    var node = context.SelectedTreeNodes.FirstOrDefault();
			if (node != null)
				Execute(node);
	    }

	    protected ILSpyPackage ILSpyPackage
	    {
		    get { return PluginFactory.GetInstance().Package as ILSpyPackage; }
	    }
    }
}

