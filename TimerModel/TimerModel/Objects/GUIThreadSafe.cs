using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace TimerModel.Objects
{
    public static class GUIThreadSafe
    {
        public static void SetAllControlsFontSize(
                   System.Windows.Forms.Control.ControlCollection ctrls,
                   int amount = 0, bool amountInPercent = true)
        {
            if (amount == 0) return;
            foreach (Control ctrl in ctrls)
            {
                // recursive
                if (ctrl.Controls != null) SetAllControlsFontSize(ctrl.Controls,
                                                                  amount, amountInPercent);
                if (ctrl != null)
                {
                    var oldSize = ctrl.Font.Size;
                    float newSize =
                       (amountInPercent) ? oldSize + oldSize * (amount / 100) : oldSize + amount;
                    if (newSize < 4) newSize = 4; // don't allow less than 4
                    var fontFamilyName = ctrl.Font.FontFamily.Name;
                    ctrl.Font = new Font(fontFamilyName, newSize);
                };
            };
        }

        private delegate void SetPropertyThreadSafeDelegate<TResult>(
    Control @this,
    Expression<Func<TResult>> property,
    TResult value);

        public static void SetPropertyThreadSafe<TResult>(
            this Control @this,
            Expression<Func<TResult>> property,
            TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member
                as PropertyInfo;

            if (propertyInfo == null ||
                !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
                @this.GetType().GetProperty(
                    propertyInfo.Name,
                    propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
                (SetPropertyThreadSafe),
                new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(
                    propertyInfo.Name,
                    BindingFlags.SetProperty,
                    null,
                    @this,
                    new object[] { value });
            }
        }
    }
}
