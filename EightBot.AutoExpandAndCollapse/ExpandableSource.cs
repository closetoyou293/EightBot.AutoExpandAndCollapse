﻿using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;
using System.Linq;

namespace EightBot.AutoExpandAndCollapse
{
	public class ExpandableSource : UITableViewSource
	{

		private readonly List<NSIndexPath> selectedPaths = new List<NSIndexPath>();

		public ExpandableSource ()
		{
		}

//		public override float EstimatedHeightForFooter (UITableView tableView, int section)
//		{
//			return UITableView.AutomaticDimension;
//		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (ExpandableTableViewCell.Key) as ExpandableTableViewCell 
				?? new ExpandableTableViewCell ();

			cell.Label1.Text = "Title " + indexPath.Row;
			cell.Label2.Text = "Subtitle " + indexPath.Row;

			return cell;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 50;
		}

		private int selectedRow = -1;

//		public override float GetHeightForRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
//		{
//			//var cell = tableView.CellAt (indexPath) as ExpandableTableViewCell;
//
//			//return cell != null 
//			//	? cell.ContentView.SystemLayoutSizeFittingSize (UIView.UILayoutFittingCompressedSize).Height
//			return UITableView.AutomaticDimension;
//		}

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.CellAt (indexPath) as ExpandableTableViewCell;


			cell.Label2.Text += " " + cell.Label2.Text;

			if(selectedPaths.Contains(indexPath))
				selectedPaths.Remove(indexPath);
			else
				selectedPaths.Add(indexPath);

			tableView.BeginUpdates ();
			tableView.EndUpdates ();

			tableView.DeselectRow (indexPath, true);
		}
	}
}

