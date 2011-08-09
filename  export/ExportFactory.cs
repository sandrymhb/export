﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Export
{
    public class ExportFactory
    {
        public static IExport CreateInstance(ExportType type,MyDocument doc)
        {
            switch (type)
            { 
                case ExportType.Xls:
                    return new ExportExcel(doc);
                case ExportType.Pdf:
                    return new ExportPdf(doc);
                default:
                    throw new ArgumentException("该类型方法未实现");
            }
        }

        public static IExport CreateInstance(string path, MyDocument doc)
        {
            string extName = Path.GetExtension(path);
            extName = extName.TrimStart(new char[] { '.' }).ToLower();
            switch (extName)
            { 
                case "xls":
                    return new ExportExcel(doc);
                case "pdf":
                    return new ExportPdf(doc);
                default:
                    throw new ArgumentException("该类型方法未实现");
            }
        }
    }
}
