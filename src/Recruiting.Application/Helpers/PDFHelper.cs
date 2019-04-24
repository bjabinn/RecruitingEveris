using iTextSharp.text;
using iTextSharp.text.pdf;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Business.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Recruiting.Application.Helpers
{
    public static class PdfHelper
    {

        public static byte[] GenerarCartaOfertaForCartaOfertaPdfViewModel(string TituloDocumento, string NombreCreador,
               CartaOfertaPdfViewModel CartaOfertaPdfViewModel, string textoCartaOfertaPDF)
        {
            //Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.A4, 0, 0, 0, 0);

            // Indicar donde vamos a guardar el documento
            var buffer = new MemoryStream();

            if (textoCartaOfertaPDF != "")
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, buffer);

                // Le colocamos el título y el autor
                doc.AddTitle(TituloDocumento);
                doc.AddCreator(NombreCreador);
                // Abrimos el archivo
                doc.Open();

                //obtemenos el texto del documento del recurso
                string[] parrafosCartaOferta = textoCartaOfertaPDF.Split('|');
                string parrafoTexto = string.Empty;
                string parrafoParametros = string.Empty;
                string[] nombresParametros = null;
                List<string> datos = new List<string>();
                string valor = string.Empty;
                var documentoPDF = new StringBuilder();


                foreach (string parrafo in parrafosCartaOferta)
                {
                    if (parrafo != string.Empty)
                    {
                        var inicio = 0;
                        //sustituimos los parametros
                        if (parrafo.IndexOf('~') > inicio)
                        {
                            parrafoTexto = parrafo.Substring(inicio, parrafo.IndexOf('~'));
                            parrafoParametros = parrafo.Substring(parrafo.IndexOf('~') + 1);
                        }
                        else
                        {
                            parrafoTexto = parrafo;
                            parrafoParametros = string.Empty;
                        }

                        if (parrafoParametros != string.Empty)
                        {
                            nombresParametros = parrafoParametros.Split('~');

                            foreach (string nombreParametro in nombresParametros)
                            {
                                var propiedad = CartaOfertaPdfViewModel.GetType().GetProperty(nombreParametro);
                                if (propiedad != null)
                                {
                                    valor = propiedad.GetValue(CartaOfertaPdfViewModel)!=null?propiedad.GetValue(CartaOfertaPdfViewModel).ToString():"";
                                }
                                else
                                {
                                    valor = "Valor del parametro no encontrado en el modelo";
                                }

                                datos.Add(valor);

                            }
                        }

                        parrafoTexto = string.Format(parrafoTexto, datos.ToArray());
                        documentoPDF.AppendLine(parrafoTexto);
                        datos.Clear();

                    }

                }

                using (var srHtml = new StringReader(documentoPDF.ToString()))
                {
                    //Interpretar el HTML
                    //iTextSharp.text.xml.
                    //descomentar
                  iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                }


                doc.Close();
            }

            return buffer.ToArray();

        }


        public static DownloadCartaGeneradaResponse GetCartaOfertaGeneradaByCartaOfertaId(ICartaOfertaRepository cartaOfertaRepository, int cartaOfertaId)
        {
            var response = new DownloadCartaGeneradaResponse() { IsValid = true };

            try
            {
                var cartaOferta = cartaOfertaRepository.GetOne(x => x.CartaOfertaId == cartaOfertaId);

                response.CartaOfertaGenerada = cartaOferta.CartaOfertaGenerada;
                response.IsValid = cartaOferta.CartaOfertaGenerada != null;


            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

    }
}
