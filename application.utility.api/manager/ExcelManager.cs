using application.utility.api.integrationevents.events;
using application.utility.api.model;
using Infrastructure.EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace application.utility.api.manager
{
    public class ExcelManager : IExcelManager
    {
        private readonly ILogger<ExcelManager> _logger;
        private readonly IEventBus _eventBus;

        public ExcelManager(ILoggerFactory loggerFactory, IEventBus eventBus)
        {
            _logger = loggerFactory.CreateLogger<ExcelManager>();
            _eventBus = eventBus;
        }


        public bool ReadFile(string filepath)
        {
            bool result = false;
            try
            {
                FileInfo file = new FileInfo(filepath);

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        MetricModel metric = new MetricModel();
                        metric.Name = worksheet.Cells[row, 1].Value.ToString();
                        metric.Tags.Add("node", worksheet.Cells[row, 2].Value.ToString());
                        for (int col = 3; col <= ColCount; col++)
                        {
                            var timestamp = long.Parse(worksheet.Cells[1, col].Value.ToString());
                            var value = worksheet.Cells[row, col].Value;
                            metric.DataPoints.Add(new DataPoint(timestamp, value));
                        }
                        MetricAddIntegrationEvent addevent = new MetricAddIntegrationEvent(metric.Name, metric.Tags, metric.DataPoints, metric.Type);
                        _eventBus.Publish(addevent);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
