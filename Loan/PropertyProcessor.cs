using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class PropertyProcessor
    {
        public string PriceText;

        public IEnumerable<IRendering> ProduceRenderings(Property property)
        {
            yield return new BoldRendering("Address:");
            yield return new TextRendering(
                " " +
                property.Address.Street + ", " +
                property.Address.PostalCode + ", " +
                property.Address.Country + ". ");
            yield return new LineBreakRendering();

            yield return new BoldRendering(this.PriceText + ":");
            yield return new TextRendering(" " + property.Price);
            yield return new LineBreakRendering();

            yield return new BoldRendering("Size:");
            yield return new TextRendering(" " + property.Size + " square meters");
            yield return new LineBreakRendering();
        }

        public override bool Equals(object obj)
        {
            var other = obj as PropertyProcessor;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.PriceText, other.PriceText);
        }

        public override int GetHashCode()
        {
            return this.PriceText.GetHashCode();
        }
    }
}
