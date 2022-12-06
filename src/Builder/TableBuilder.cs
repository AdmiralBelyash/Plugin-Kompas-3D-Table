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
        /// Параметры стола.
        /// </summary>
        private TableParameters _tableParameters;

        /// <summary>
        /// Сапр апи.
        /// </summary>
        private IWrapper _apiService;

        /// <summary>
        /// Метод для создания стола.
        /// </summary>
        /// <param name="tableParameters"> Параметры стола. </param>
        /// <param name="apiService"> Сапр апи. </param>
        public void BuildTable(TableParameters tableParameters, IWrapper apiService)
        {
            _apiService = apiService;
            _tableParameters = tableParameters;

            _apiService.CreateDocument();

            _createTableTop();
            _createRightTopTableLeg();
            _createRightBottomTableLeg();
            _createLeftTopTableLeg();
            _createLeftBottomTableLeg();
        }


        /// <summary>
        /// Создание столешницы.
        /// </summary>
        private void _createTableTop()
        {
            var points = new List<PointF>
            {
                _apiService.CreatePoint(0, 0),
                _apiService.CreatePoint(_tableParameters.TableParameterCollection[ParameterType.TableWidth].Value,
                    _tableParameters.TableParameterCollection[ParameterType.TableLength].Value),
            };

            var sketchXy = _apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            _apiService.Extrude(sketchXy, _tableParameters.TableParameterCollection[ParameterType.TableThickness].Value);
            _apiService.RoundCorners(_tableParameters.TableParameterCollection[ParameterType.TableThickness].Value);
        }

        /// <summary>
        /// Создание ножки.
        /// </summary>
        private void _createRightTopTableLeg()
        {
            var points = new List<PointF>
            {
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value
                    + _tableParameters.GetLegsWidth(),
                    _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    + _tableParameters.GetLegsWidth()),
            };

            var sketchXy = _apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            _apiService.Extrude(sketchXy, _tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }

        /// <summary>
        /// Создание ножки.
        /// </summary>
        private void _createRightBottomTableLeg()
        {
            var points = new List<PointF>
            {
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    _tableParameters.TableParameterCollection[ParameterType.TableLength].Value
                    - _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    - _tableParameters.GetLegsWidth()),
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value 
                    + _tableParameters.GetLegsWidth(),
                    _tableParameters.TableParameterCollection[ParameterType.TableLength].Value -
                     _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
            };

            var sketchXy = _apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            _apiService.Extrude(sketchXy, _tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }

        /// <summary>
        /// Создание ножки.
        /// </summary>
        private void _createLeftTopTableLeg()
        {
            var points = new List<PointF>
            {
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidth].Value
                    - _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value
                    - _tableParameters.GetLegsWidth(),
                    _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidth].Value
                     - _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    + _tableParameters.GetLegsWidth()),
            };

            var sketchXy = _apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            _apiService.Extrude(sketchXy, _tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }

        /// <summary>
        /// Создание ножки.
        /// </summary>
        private void _createLeftBottomTableLeg()
        {
            var points = new List<PointF>
            {
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidth].Value 
                    - _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value
                    - _tableParameters.GetLegsWidth(),
                    _tableParameters.TableParameterCollection[ParameterType.TableLength].Value 
                    - _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value
                    - _tableParameters.GetLegsWidth()),
                _apiService.CreatePoint(
                    _tableParameters.TableParameterCollection[ParameterType.TableWidth].Value
                     - _tableParameters.TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value,
                    _tableParameters.TableParameterCollection[ParameterType.TableLength].Value -
                     _tableParameters.TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value),
            };

            var sketchXy = _apiService.CreateNewSketch(3);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            _apiService.Extrude(sketchXy, _tableParameters.TableParameterCollection[ParameterType.TableHeight].Value);
        }
    }
}
