using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iConnect
{
    public partial class DescriptionPage : ContentPage
    {
        
        public DescriptionPage()
        {
            InitializeComponent();

            Label HeadingLabel,SubLabel;

            for (int i = 0; i < TotalLists.SelectedNGO.Sections.Count; i++)
            {
                HeadingLabel = new Label();
                HeadingLabel.TextColor = Color.Navy;
                HeadingLabel.FontSize = 20;
                HeadingLabel.Margin = 2;
                HeadingLabel.Text = TotalLists.SelectedNGO.Sections[i].Heading;
                stacklayout.Children.Add(HeadingLabel);

				List<string> keysList = new List<string>(TotalLists.SelectedNGO.Sections[i].Fields.Keys);
				List<string> ValuesList = new List<string>(TotalLists.SelectedNGO.Sections[i].Fields.Values);

				for (int j = 0; j < keysList.Count; j++)
                {
                    SubLabel = new Label();
                    SubLabel.Margin = 1;
                    SubLabel.Text = keysList[j] + " : " + ValuesList[j];
                    stacklayout.Children.Add(SubLabel);
                }
            }
          	
        }

       
    }

}
