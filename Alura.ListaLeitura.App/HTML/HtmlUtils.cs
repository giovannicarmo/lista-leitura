using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Alura.ListaLeitura.App.HTML
{
    public class HtmlUtils
    {
        public static string CarregaArquivoHtml(string nomeArquivo)
        {
            var caminho = $"HTML/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(caminho))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
