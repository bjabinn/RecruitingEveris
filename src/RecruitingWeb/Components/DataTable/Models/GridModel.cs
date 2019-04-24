using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class GridModel<TModel>
    {
        private readonly IEnumerable<TModel> _modelData;
        private Func<TModel, string> _primaryKey;
        private string _id;
        private bool _usePrimaryKeyForId;


        private string _ajaxUrl;
        private int _pageSize;
        private bool _paginable;
        private int _initialPage;
        private string _customFilterHandler;
        

        public GridModel(IEnumerable<TModel> model)
        {
            _modelData = model;
            ColumnsData = new List<BaseColumn<TModel>>();
            RowTemplatesDefinition = new List<RowTemplateDefinition<TModel>>();
            FootTemplatesDefinition = new List<FooterTemplateDefinition>();
            DefaultTableClass = " gridTable dataTable table table-striped ";
            _usePrimaryKeyForId = true;

            _ajaxUrl = null;
            _pageSize = 10;
            _paginable = false;
            
        }

        public GridModel()
        {
            ColumnsData = new List<BaseColumn<TModel>>();
            RowTemplatesDefinition = new List<RowTemplateDefinition<TModel>>();
            FootTemplatesDefinition = new List<FooterTemplateDefinition>();
            DefaultTableClass = " gridTable dataTable table table-striped ";
            _usePrimaryKeyForId = true;

            _ajaxUrl = null;
            _pageSize = 10;
            _paginable = false;
       
        }

        public string Id
        {
            get
            {
                if (_usePrimaryKeyForId)
                {
                    return _id + (_modelData.Any() ? ResolvedPrimaryKey(_modelData.First()) : null);
                }
                return _id;
            }
        }

        public List<BaseColumn<TModel>> ColumnsData { get; private set; }

        public List<RowTemplateDefinition<TModel>> RowTemplatesDefinition { get; private set; }

       
        public List<FooterTemplateDefinition> FootTemplatesDefinition { get; private set; }
        
        
        public IEnumerable<TModel> ModelData
        {
            get
            {
                return _modelData;
            }
        }

        public string DefaultTableClass { get; private set; }

        public string TableClass { get; set; }

        public Func<TModel, HelperResult> CustomHeader { get; set; }

        public bool UseCustomHeader { get; set; }

        public string Dom
        {
            get
            {
                return "tipr";
            }
        }

        public string ResolvedPrimaryKey(TModel modelRow)
        {
            return _primaryKey != null ? _primaryKey(modelRow) : null;
        }

        public GridModel<TModel> Name(string name)
        {
            _id = name;
            return this;
        }

        public GridModel<TModel> AddPrimaryKeyToName(bool usePrimaryKey)
        {
            _usePrimaryKeyForId = usePrimaryKey;
            return this;
        }

        public GridModel<TModel> Columns(Action<ColumnDefinitionFactory<TModel>> builder)
        {
            var factory = new ColumnDefinitionFactory<TModel>(this);
            builder(factory);
            return this;
        }

        public GridModel<TModel> RowTemplates(Action<RowTemplateFactory<TModel>> builder)
        {
            var factory = new RowTemplateFactory<TModel>(this);
            builder(factory);
            return this;
        }

        public GridModel<TModel> FootTemplates(Action<FootTemplateFactory<TModel>> builder)
        {
            var factory = new FootTemplateFactory<TModel>(this);
            builder(factory);
            return this;
        }

        public GridModel<TModel> PrimaryKey(Func<TModel, string> primaryKeyExpression)
        {
            _primaryKey = primaryKeyExpression;
            return this;
        }



        public GridModel<TModel> AjaxLoadUrl(string ajaxUrl)
        {
            _ajaxUrl = ajaxUrl;
            return this;
        }

        public string GetAjaxLoadUrl()
        {
            return _ajaxUrl;
        }

        public GridModel<TModel> Paginable(bool paginable = true)
        {
            _paginable = paginable;
            return this;
        }

        public GridModel<TModel> InitialPage(int initialPage)
        {
            _initialPage = initialPage;
            return this;
        }

        public int GetInitialPage()
        {
            return _initialPage;
        }

        public bool GetPaginable()
        {
            return _paginable;
        }

        public GridModel<TModel> PageSize(int pageSize = 10)
        {
            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            _pageSize = pageSize;
            _paginable = true;
            return this;
        }


        public int GetPageSize()
        {
            return _pageSize;
        }

        public GridModel<TModel> CustomFilterAjax(string handler)
        {
            _customFilterHandler = handler;
            return this;
        }
        
        public string GetCustomFilterHandler()
        {
            return _customFilterHandler;
        }
    }
}