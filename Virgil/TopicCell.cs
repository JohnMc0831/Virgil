using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Virgil
{
    class TopicCell : ViewCell
    {
        public string Text { get; set; }
        public TopicCell()
        {
            //var image = new Image
            //{
            //    HorizontalOptions = LayoutOptions.Start
            //};
           // image.SetBinding(Image.SourceProperty, new Binding("ImageUri"));

            var title = new Label();
            title.SetBinding(Label.TextProperty, "Title");
            

           // image.WidthRequest = image.HeightRequest = 40;
           // image.Source = new Uri("http://www.placebear.com/40/40");  //For demo purposes.

            var topicLayout = CreateTopicLayout();

            //var viewLayout = new StackLayout()
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    Children = { image, topicLayout}
            //};
            View = topicLayout;
            Text = title.Text;
        }

        static StackLayout CreateTopicLayout()
        {

            var titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            titleLabel.SetBinding(Label.TextProperty, "Title");
            //titleLabel.SetBinding(VisualElement.BackgroundColorProperty, "BackColor");
            //titleLabel.SetBinding(Label.TextColorProperty, "TextColor");

            var detailLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.OnPlatform(10f, 10f, 10f)
            };
            detailLabel.SetBinding(Label.TextProperty, "Summary");

            var topicLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { titleLabel, detailLabel }
            };
            return topicLayout;
        }

    }
}
