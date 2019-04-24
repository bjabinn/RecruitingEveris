using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RecruitingWeb.Components.Searchable
{
    public static class SearchableExtension
    {
        public static Searchable Searchable(this HtmlHelper html, string name, UrlHelper url)
        {
            return new Searchable(name, url);
        }
    }

    public class Searchable : IHtmlString
    {
        private readonly UrlHelper _url;
        private string _name;
        private string _id;
        private string _textName;

        private string _action;
        private string _controller;
        private string _visibleValue;
        private string _hiddenValue;
        private string _readonlyValue;
        private bool _isRequired;

        private readonly List<string> _htmlClassList;

        public Searchable(string name, UrlHelper url)
        {
            _name = name;
            _url = url;
            _htmlClassList = new List<string>();
            _isRequired = false;
        }

        public Searchable Name(string name)
        {
            _name = name;
            return this;
        }

        //modifica el name del campo de texto mostrado en pantalla.
        public Searchable TextName(string name)
        {
            _textName = name;
            return this;
        }

        public Searchable Id(string id)
        {
            _id = id;
            return this;
        }

        public Searchable Required(bool required)
        {
            _isRequired = required;
            return this;
        }

        public Searchable AddCssClass(string cssClass)
        {
            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                _htmlClassList.Add(cssClass);
            }
            return this;
        }

        public Searchable Action(string action, string controller = null)
        {
            _action = action;
            _controller = controller;
            return this;
        }


        public Searchable Value(string visibleValue,string hiddenValue=null,string readonlyValue="")
        {
            if (hiddenValue == null)
            {
                hiddenValue = visibleValue;
            }
            _hiddenValue = hiddenValue;
            _visibleValue = visibleValue;
            if (readonlyValue !="")
            {
                _readonlyValue = readonlyValue;
            }
           
            return this;
        }


         

        public string ToHtmlString()
        {
            var html = new TagBuilder("div");
            html.MergeAttribute("data-role", "searchable", true);

            var input = GetInput();
            var inputHidden = GetInputHidden();

            var javascript = GetJavaScript(input);
            var listaResultados = GetListaResultados();

            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append(input.ToString());
            htmlBuilder.Append(inputHidden.ToString());
            htmlBuilder.Append(listaResultados.ToString());
            htmlBuilder.Append(javascript.ToString());

            html.InnerHtml = htmlBuilder.ToString();

            return html.ToString();
        }

        private TagBuilder GetInput()
        {
            var input = new TagBuilder("input");

            input.MergeAttribute("data-searchable-input", "text", true);
            //si no nos han introducido un name custom para el campo visible de texto
            if (string.IsNullOrEmpty(_textName))
            {
                input.MergeAttribute("name", string.Format("{0}-Text", _name), true);
            }
            else
            {
                input.MergeAttribute("name", _textName, true);
            }
            input.MergeAttribute("type", "text", true);
            input.MergeAttribute("autocomplete", "off", true);


            var id = string.Format("{0}-Text", _id);
            input.GenerateId(id);

            if (!string.IsNullOrWhiteSpace(_visibleValue))
            {
                input.MergeAttribute("value", _visibleValue, true);
            }

            if (!string.IsNullOrWhiteSpace(_readonlyValue))
            {
                input.MergeAttribute("readonly", _readonlyValue, true);
            }

            foreach (var cssClass in _htmlClassList)
            {
                input.AddCssClass(cssClass);
            }

            return input;
        }

        private TagBuilder GetInputHidden()
        {
            var input = new TagBuilder("input");

            input.MergeAttribute("data-searchable-input", "hidden", true);
            input.MergeAttribute("name",  _name, true);
            input.MergeAttribute("type", "text", true);
            input.AddCssClass("hide");

            var id = _id;
            input.GenerateId(id);

            if (!string.IsNullOrWhiteSpace(_hiddenValue))
            {
                input.MergeAttribute("value", _hiddenValue, true);
            }
            
            if (_isRequired)
            {
                input.MergeAttribute("required", "required", true);
            }

            return input;
        }

        private TagBuilder GetJavaScript(TagBuilder input)
        {
            var javascript = new TagBuilder("script");
            javascript.MergeAttribute("type", "text/javascript", true);

            var id = input.Attributes["id"];
            var url = _url.Action(_action, _controller);

            var javacode = new StringBuilder();

            javacode.AppendLine("loadRegisterCallback(function () {{");

            javacode.AppendLine(string.Format("    var source = $('#{0}');", id));
            javacode.AppendLine(string.Format("    var url = '{0}';", url));
            javacode.AppendLine("    source.Searchable(url);");

            javacode.AppendLine("}});");
            javascript.InnerHtml = javacode.ToString();


            return javascript;
        }

        private TagBuilder GetListaResultados()
        {
            var lista = new TagBuilder("ul");
            lista.AddCssClass("hide");
            lista.AddCssClass("searchable-results");
            lista.MergeAttribute("name",string.Format("{0}-Resultados", _name), true);
            return lista;
        }
    }
}