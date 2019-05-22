using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Rock.Web.UI.Controls;

namespace Rock.Field.Types
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Rock.Field.FieldType" />
    public class ConditionalScaleFieldType : FieldType
    {
        #region ConfigurationKeys

        private static class ConfigurationKey
        {
            public static string ConfigurationJSON = "ConfigurationJSON";
        }

        #endregion ConfigurationKeys

        #region Configuration

        /// <summary>
        /// Returns a list of the configuration keys
        /// </summary>
        /// <returns></returns>
        public override List<string> ConfigurationKeys()
        {
            var keys = base.ConfigurationKeys();
            keys.Add( ConfigurationKey.ConfigurationJSON );
            return keys;
        }

        /// <summary>
        /// Creates the HTML controls required to configure this type of field
        /// </summary>
        /// <returns></returns>
        public override List<Control> ConfigurationControls()
        {
            var controls = base.ConfigurationControls();

            var conditionalScaleControlsPlaceHolder = new DynamicPlaceholder();
            controls.Add( conditionalScaleControlsPlaceHolder );

            return controls;
        }

        public override void SetConfigurationValues( List<Control> controls, Dictionary<string, ConfigurationValue> configurationValues )
        {
            base.SetConfigurationValues( controls, configurationValues );

            if ( controls == null || controls.Count < 1 )
            {
                return;
            }

            var conditionalScaleControlsPlaceHolder = controls[0] as DynamicPlaceholder;
            conditionalScaleControlsPlaceHolder.Controls.Clear();

            var configurationJSON = configurationValues.GetValueOrNull( ConfigurationKey.ConfigurationJSON );

            List<ConditionalScaleRange> conditionalScaleRangeList = configurationJSON.FromJsonOrNull<List<ConditionalScaleRange>>() ?? new List<ConditionalScaleRange>();
            conditionalScaleRangeList = conditionalScaleRangeList.OrderBy( a => a.RangeOrder ).ThenBy( a => a.Label ).ToList();
            if ( !conditionalScaleRangeList.Any() )
            {
                conditionalScaleRangeList.Add( new ConditionalScaleRange() );
            }

            foreach ( var conditionalScaleRange in conditionalScaleRangeList )
            {
                Panel pnlRow = new Panel { ID = "pnlRow", CssClass = "row" };
                Panel pnlColumn1 = new Panel { ID = "pnlColumn1", CssClass = "col-md-6" };
                var labelTextBox = new RockTextBox { ID = "labelTextBox", Placeholder = "Label", CssClass="margin-b-md" };
                pnlColumn1.Controls.Add( labelTextBox );
                var upperValueNumberBox = new NumberBox { ID = "upperValueNumberBox", Placeholder = "Upper Value", CssClass = "margin-b-md" };
                pnlColumn1.Controls.Add( upperValueNumberBox );
                pnlRow.Controls.Add( pnlColumn1 );

                Panel pnlColumn2 = new Panel { ID = "pnlColumn2", CssClass = "col-md-6" };
                var colorPicker = new ColorPicker { ID = "colorPicker", CssClass = "margin-b-md" };
                pnlColumn2.Controls.Add( colorPicker );
                var lowerValueNumberBox = new NumberBox { ID = "lowerValueNumberBox", Placeholder = "Lower Value" };
                pnlColumn2.Controls.Add( lowerValueNumberBox );

                pnlRow.Controls.Add( pnlColumn2 );

                conditionalScaleControlsPlaceHolder.Controls.Add( pnlRow );

                conditionalScaleControlsPlaceHolder.Controls.Add( new HtmlGenericControl( "hr" ) );
            }
        }

        public override Dictionary<string, ConfigurationValue> ConfigurationValues( List<Control> controls )
        {
            return base.ConfigurationValues( controls );
        }

        #endregion Configuration

        #region Classes

        private class ConditionalScaleRange
        {
            public int RangeOrder { get; set; }
            public string Label { get; set; }
            public string Color { get; set; }
            public decimal UpperValue { get; set; }
            public decimal LowerValue { get; set; }
        }

        #endregion
    }
}
