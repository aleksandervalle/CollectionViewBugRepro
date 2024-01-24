using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewBugRepro
{
    public interface ListItem
    {
        string Text { get; }
    }

    public class First : ListItem
    {
        public string Text => "First";
    }

    public class TheRest : ListItem
    {
        public string Text => "The Rest";
    }

    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateOne { get; set; }
        public DataTemplate TemplateTwo { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is First)
            {
                return TemplateOne;
            }
            else
            {
                return TemplateTwo;
            }
        }
    }

}
