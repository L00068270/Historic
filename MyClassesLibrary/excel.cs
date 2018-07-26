using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace MyClassesLibrary
{
    /*will have to define path to excel file*/
    class excel
    { 
        string path = " ";
        _Application _excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;



        /*constructer here*/
        public excel(string path, int sheet)
        {
            this.path = path;
            wb = _excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        /*now read in excel file*/
        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value != null)
                return ws.Cells[i, j].Values2;
            else return "";
        }
    }
}
