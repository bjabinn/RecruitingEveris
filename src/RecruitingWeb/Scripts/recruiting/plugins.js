﻿
//set default format to datepicker
jQuery(function ($) {
    
    //Se añade 1 año al máximo a elegir del datepicker
    var anio = (new Date).getFullYear() + 1; 
    $.datepicker.setDefaults({
       dateFormat: 'dd/mm/yy',
       yearRange: "1900:" + anio,
       Date: "hh:mm:ss",
       use24Hours: true,
        local:'es'
    });


    
});


$.fn.Searchable = function (url) {

    this.each(function () {
        var source = $(this);
        var parent = source.parent();
        var elemDiv = source.parentsUntil($(".div"), ".row");

        source.on('keyup', function () {

            var ulResultados = source.nextAll('.searchable-results');
            ulResultados.html('');
            ulResultados.addClass('hide');

            var oldTimeOut = source.data('timeOutId');

            if (oldTimeOut != null) {
                clearTimeout(oldTimeOut);
                source.removeData('timeOutId');
            }

            if (source.val().length >= 2) {

                var timeOutId = setTimeout(function () {
                    source.removeData('timeOutId');
                    var textSearch = source.val();
                    var promise = $.ajax({
                        url: url,
                        data: { textSearch: textSearch },
                        type: 'POST',
                    });

                    promise.done(function (response) {

                        if (response.IsValid) {
                            var ulResultados = source.nextAll('.searchable-results');
                            ulResultados.html('');
                            if ((response.Items != null) && (response.Items.length > 0)) {
                                ulResultados.removeClass('hide');
                                response.Items.forEach(function (item) {
                                    var liItem = $('<li>');
                                    liItem.attr('data-value', item.Value);
                                    liItem.html(item.Text);
                                    liItem.appendTo(ulResultados);
                                    liItem.addClass('searchable-item');
                                    var cadenaQueEscribimos = removeDiacritics(item.Text);
                                    var cadenaResultado = removeDiacritics(source.val());
                                    if (cadenaQueEscribimos.toLowerCase() == cadenaResultado.toLowerCase())
                                    {
                                        guardaValor(item.Text, item.Value, source);
                                    }
                                    else
                                    {
                                        borraValor(source);
                                    }
                                });
                            }

                        } else {
                            alert(response.ErrorMessage);
                        }
                    });


                }, 1000);

                source.data('timeOutId', timeOutId);
            } else {

            }

        });

        source.on('change', function () {
            if (source.val() == "") {
                source.parent().find('[data-searchable-input="hidden"]').val("");
            }
        });

        parent.on('click', '.searchable-results .searchable-item', function () {
            var item = $(this);
            var textField = parent.find('[data-searchable-input="text"]');
            var hiddenField = parent.find('[data-searchable-input="hidden"]');

            textField.val(item.html());
            hiddenField.val(item.attr('data-value'));

            var ulResultados = parent.find('.searchable-results');
            ulResultados.html('');
            ulResultados.addClass('hide');
        });

     
       elemDiv.on('click', function () {
            var ulResultados = parent.find('.searchable-results');
            ulResultados.html('');
            ulResultados.addClass('hide');
        });

       function guardaValor(text, value, searchableSource)
       {
           var textField = searchableSource.find('[data-searchable-input="text"]');
           var hiddenField = searchableSource.parent().find('[data-searchable-input="hidden"]');

           textField.val(text);
           hiddenField.val(value);
       }

       function borraValor(searchableSource)
       {
           var hiddenField = searchableSource.parent().find('[data-searchable-input="hidden"]');
           hiddenField.val("");
       }

    });

    //metodo para quitar acentos: 

    var defaultDiacriticsRemovalMap = [
    { 'base': 'A', 'letters': '\u0041\u24B6\uFF21\u00C0\u00C1\u00C2\u1EA6\u1EA4\u1EAA\u1EA8\u00C3\u0100\u0102\u1EB0\u1EAE\u1EB4\u1EB2\u0226\u01E0\u00C4\u01DE\u1EA2\u00C5\u01FA\u01CD\u0200\u0202\u1EA0\u1EAC\u1EB6\u1E00\u0104\u023A\u2C6F' },
    { 'base': 'C', 'letters': '\u0043\u24B8\uFF23\u0106\u0108\u010A\u010C\u00C7\u1E08\u0187\u023B\uA73E' },
    { 'base': 'E', 'letters': '\u0045\u24BA\uFF25\u00C8\u00C9\u00CA\u1EC0\u1EBE\u1EC4\u1EC2\u1EBC\u0112\u1E14\u1E16\u0114\u0116\u00CB\u1EBA\u011A\u0204\u0206\u1EB8\u1EC6\u0228\u1E1C\u0118\u1E18\u1E1A\u0190\u018E' },
    { 'base': 'I', 'letters': '\u0049\u24BE\uFF29\u00CC\u00CD\u00CE\u0128\u012A\u012C\u0130\u00CF\u1E2E\u1EC8\u01CF\u0208\u020A\u1ECA\u012E\u1E2C\u0197' },
    { 'base': 'N', 'letters': '\u004E\u24C3\uFF2E\u01F8\u0143\u00D1\u1E44\u0147\u1E46\u0145\u1E4A\u1E48\u0220\u019D\uA790\uA7A4' },
    { 'base': 'O', 'letters': '\u004F\u24C4\uFF2F\u00D2\u00D3\u00D4\u1ED2\u1ED0\u1ED6\u1ED4\u00D5\u1E4C\u022C\u1E4E\u014C\u1E50\u1E52\u014E\u022E\u0230\u00D6\u022A\u1ECE\u0150\u01D1\u020C\u020E\u01A0\u1EDC\u1EDA\u1EE0\u1EDE\u1EE2\u1ECC\u1ED8\u01EA\u01EC\u00D8\u01FE\u0186\u019F\uA74A\uA74C' },
    { 'base': 'U', 'letters': '\u0055\u24CA\uFF35\u00D9\u00DA\u00DB\u0168\u1E78\u016A\u1E7A\u016C\u00DC\u01DB\u01D7\u01D5\u01D9\u1EE6\u016E\u0170\u01D3\u0214\u0216\u01AF\u1EEA\u1EE8\u1EEE\u1EEC\u1EF0\u1EE4\u1E72\u0172\u1E76\u1E74\u0244' },
    { 'base': 'a', 'letters': '\u0061\u24D0\uFF41\u1E9A\u00E0\u00E1\u00E2\u1EA7\u1EA5\u1EAB\u1EA9\u00E3\u0101\u0103\u1EB1\u1EAF\u1EB5\u1EB3\u0227\u01E1\u00E4\u01DF\u1EA3\u00E5\u01FB\u01CE\u0201\u0203\u1EA1\u1EAD\u1EB7\u1E01\u0105\u2C65\u0250' },
    { 'base': 'c', 'letters': '\u0063\u24D2\uFF43\u0107\u0109\u010B\u010D\u00E7\u1E09\u0188\u023C\uA73F\u2184' },
    { 'base': 'e', 'letters': '\u0065\u24D4\uFF45\u00E8\u00E9\u00EA\u1EC1\u1EBF\u1EC5\u1EC3\u1EBD\u0113\u1E15\u1E17\u0115\u0117\u00EB\u1EBB\u011B\u0205\u0207\u1EB9\u1EC7\u0229\u1E1D\u0119\u1E19\u1E1B\u0247\u025B\u01DD' },
    { 'base': 'i', 'letters': '\u0069\u24D8\uFF49\u00EC\u00ED\u00EE\u0129\u012B\u012D\u00EF\u1E2F\u1EC9\u01D0\u0209\u020B\u1ECB\u012F\u1E2D\u0268\u0131' },
    { 'base': 'n', 'letters': '\u006E\u24DD\uFF4E\u01F9\u0144\u00F1\u1E45\u0148\u1E47\u0146\u1E4B\u1E49\u019E\u0272\u0149\uA791\uA7A5' },
    { 'base': 'o', 'letters': '\u006F\u24DE\uFF4F\u00F2\u00F3\u00F4\u1ED3\u1ED1\u1ED7\u1ED5\u00F5\u1E4D\u022D\u1E4F\u014D\u1E51\u1E53\u014F\u022F\u0231\u00F6\u022B\u1ECF\u0151\u01D2\u020D\u020F\u01A1\u1EDD\u1EDB\u1EE1\u1EDF\u1EE3\u1ECD\u1ED9\u01EB\u01ED\u00F8\u01FF\u0254\uA74B\uA74D\u0275' },
    { 'base': 'u', 'letters': '\u0075\u24E4\uFF55\u00F9\u00FA\u00FB\u0169\u1E79\u016B\u1E7B\u016D\u00FC\u01DC\u01D8\u01D6\u01DA\u1EE7\u016F\u0171\u01D4\u0215\u0217\u01B0\u1EEB\u1EE9\u1EEF\u1EED\u1EF1\u1EE5\u1E73\u0173\u1E77\u1E75\u0289' },
    ];

    var diacriticsMap = {};
    for (var i = 0; i < defaultDiacriticsRemovalMap.length; i++) {
        var letters = defaultDiacriticsRemovalMap[i].letters;
        for (var j = 0; j < letters.length ; j++) {
            diacriticsMap[letters[j]] = defaultDiacriticsRemovalMap[i].base;
        }
    }

    function removeDiacritics(str) {
        return str.replace(/[^\u0000-\u007E]/g, function (a) {
            return diacriticsMap[a] || a;
        });
    }

};
