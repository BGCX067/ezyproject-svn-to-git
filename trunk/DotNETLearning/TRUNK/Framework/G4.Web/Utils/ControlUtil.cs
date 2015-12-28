using System.Collections.Generic;
using System.Web.UI;

namespace G4.Web.Utils
{
    public class ControlUtil
    {
        /// <summary>
        /// Finds the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        public static T FindControl<T>(ControlCollection controls) where T : Control
        {
            T found = default(T);

            if (controls != null && controls.Count > 0)
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i] is T)
                    {
                        found = controls[i] as T;
                        break;
                    }
                    else
                        found = FindControl<T>(controls[i].Controls);
                }
            }

            return found;
        }

        /// <summary>
        /// Finds the controls by specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        public static IEnumerable<T> FindControls<T>(ControlCollection controls) where T : Control
        {
            T found;

            if (controls != null && controls.Count > 0)
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i] is T)
                    {
                        found = controls[i] as T;
                        yield return found;
                    }
                    else
                        FindControl<T>(controls[i].Controls);
                }
            }
        }

        /// <summary>
        /// Recursively searches for a server control with the given ID.
        /// </summary>
        /// <param name="control">Parent control </param>
        /// <param name="id">ID of control to find</param>
        /// <returns>The matching control or null if no match was found</returns>
        public static Control FindControl(Control control, string id)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl.ID == id)
                    return ctl;

                Control child = FindControl(ctl, id);
                if (child != null)
                    return child;
            }
            return null;
        }
    }
}