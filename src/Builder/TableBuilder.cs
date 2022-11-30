using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasApi;
using Model;

namespace Builder
{
    public class TableBuilder
    {
        /// <summary>
        /// Метод для создания стола.
        /// </summary>
        /// <param name="tableParameters">Параметры стола</param>
        /// <param name="apiService">Компас апи</param>
        public void BuildTable(TableParameters tableParameters, KompasWrapper apiService)
        {
            apiService.CreateDocument();

            _createTableTop(tableParameters, apiService);
            _createRightTopTableLeg(tableParameters, apiService);
            _createRightBottomTableLeg(tableParameters, apiService);
            _createLeftTopTableLeg(tableParameters, apiService);
            _createLeftBottomTableLeg(tableParameters, apiService);
        }

        private void _createTableTop(TableParameters tableParameters, KompasWrapper apiService)
        {
            var points = new List<PointF>
            {
                apiService.CreatePoint(0, 0),
                apiService.CreatePoint(tableParameters.TableParameterCollection[ParameterType.TableWidth].Value,
                    tableParameters.TableParameterCollection[ParameterType.TableLength].Value),
            };

            var sketchXy = apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            apiService.Extrude(sketchXy, tableParameters.TableParameterCollection[ParameterType.TableThickness].Value);
        }

        private void _createRightTopTableLeg(TableParameters tableParameters, KompasWrapper apiService)
        {
            var points = new List<PointF>
            {
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value
                    + tableParameters.GetLegsWidth(),
                    tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    + tableParameters.GetLegsWidth()),
            };

            var sketchXy = apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            apiService.Extrude(sketchXy, tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }

        private void _createRightBottomTableLeg(TableParameters tableParameters, KompasWrapper apiService)
        {
            var points = new List<PointF>
            {
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    tableParameters.TableParameterCollection[ParameterType.TableLength].Value
                    - tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    - tableParameters.GetLegsWidth()),
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value 
                    + tableParameters.GetLegsWidth(),
                    tableParameters.TableParameterCollection[ParameterType.TableLength].Value -
                     tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
            };

            var sketchXy = apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            apiService.Extrude(sketchXy, tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }

        private void _createLeftTopTableLeg(TableParameters tableParameters, KompasWrapper apiService)
        {
            var points = new List<PointF>
            {
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidth].Value
                    - tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value
                    - tableParameters.GetLegsWidth(),
                    tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidth].Value
                     - tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    + tableParameters.GetLegsWidth()),
            };

            var sketchXy = apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            apiService.Extrude(sketchXy, tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }

        private void _createLeftBottomTableLeg(TableParameters tableParameters, KompasWrapper apiService)
        {
            var points = new List<PointF>
            {
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidth].Value 
                    - tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value
                    - tableParameters.GetLegsWidth(),
                    tableParameters.TableParameterCollection[ParameterType.TableLength].Value 
                    - tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    - tableParameters.GetLegsWidth()),
                apiService.CreatePoint(
                    tableParameters.TableParameterCollection[ParameterType.TableWidth].Value
                     - tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    tableParameters.TableParameterCollection[ParameterType.TableLength].Value -
                     tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
            };

            var sketchXy = apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            apiService.Extrude(sketchXy, tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }
    }
}
