using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UFCW.Services.Models.NonCore
{
    public class NonCoreResponse:BaseResponse
    {
		public List<FAQ> FAQ { get; set; }
		public List<LinkResponse> Links { get; set; }
		public List<News> News { get; set; }
		public List<Document> Documents { get; set; }
		public List<NewsLetter> NewsLetters { get; set; }
		public string AboutUS { get; set; }
    }
}
public class LinkResponse
{
	public string LinkCategory { get; set; }
	public string LinkCategoryDescription { get; set; }
	public List<Link> Links { get; set; }
}

public class LinkCategory
{
	public string LinkCategoryID { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string DateCreated { get; set; }
	public string DateUpdated { get; set; }
}

public class Link
{
	public string LinkID { get; set; }
	public int LinkType { get; set; } //
	public string Name { get; set; }
	public string Description { get; set; }
	public string Url { get; set; }
	public LinkCategory LinkCategory { get; set; }
	public string Tags { get; set; }
	public string DateCreated { get; set; }
	public string DateUpdated { get; set; }
}

public class NewsCategory
{
	public string NewsCategoryID { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string DateCreated { get; set; }
	public string DateUpdated { get; set; }
}

public class News
{
	public string NewsID { get; set; }
	public string Title { get; set; }
	public string SubTitle { get; set; }
	public string Preview { get; set; }
	public string Content { get; set; }
	public NewsCategory NewsCategory { get; set; }
	public string TitleImage { get; set; }
	public string TitleVideo { get; set; }
	public string Tags { get; set; }
	public string DateCreated { get; set; }
	public string DateUpdated { get; set; }
}

public class Document
{
	public string PdfDocumentID { get; set; }
	public string FileName { get; set; }
	public string Url { get; set; }
	public double FileSize { get; set; }//
	public string DocumentBlob { get; set; }
	public string Title { get; set; }
	public string Tags { get; set; }
	public string DateCreated { get; set; }
	public string DateUpdated { get; set; }
}

public class NewsLetter: INotifyPropertyChanged
{
	public string NewsLetterID { get; set; }
	public string Title { get; set; }
	public string Template { get; set; }
	public string OrganizationID { get; set; }
	public string DateCreated { get; set; }
	public string DateUpdated { get; set; }
    public bool isVisible { get; set; }
    public int height { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;


	public bool IsVisible
	{
		get { return isVisible; }
		set
		{
			if (isVisible != value)
			{
				isVisible = value;
				OnPropertyChanged("IsVisible");
			}
		}
	}

	public int Height
	{
		get { return height; }
		set
		{
			if (height != value)
			{
				height = value;
				OnPropertyChanged("Height");
			}
		}
	}

	/// <summary>
	/// Ons the property changed.
	/// </summary>
	/// <param name="propertyName">Property name.</param>
	protected virtual void OnPropertyChanged(string propertyName)
	{
		var changed = PropertyChanged;
		if (changed != null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}