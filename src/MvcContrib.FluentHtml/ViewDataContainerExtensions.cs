using System.Collections;
using System.Web.Mvc;
using MvcContrib.FluentHtml.Behaviors;
using MvcContrib.FluentHtml.Elements;
using System.Collections.Generic;

namespace MvcContrib.FluentHtml
{
	/// <summary>
	/// Extensions to IViewDataContainer
	/// </summary>
	public static class ViewDataContainerExtensions
	{
		/// <summary>
		/// Generate an HTML input element of type 'text' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static TextBox TextBox(this IViewDataContainer view, string name)
		{
			return new TextBox(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'password' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static Password Password(this IViewDataContainer view, string name)
		{
			return new Password(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML select element and set its selected value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static Select Select(this IViewDataContainer view, string name)
		{
			return new Select(name, null, view.GetBehaviors()).Selected(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML select element with a multiselect attribute = 'true' and set its selected 
		/// values from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static MultiSelect MultiSelect(this IViewDataContainer view, string name)
		{
			return new MultiSelect(name, null, view.GetBehaviors()).Selected(view.ViewData.Eval(name) as IEnumerable);
		}

		/// <summary>
		/// Generate an HTML input element of type 'hidden' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static Hidden Hidden(this IViewDataContainer view, string name)
		{
			return new Hidden(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML textarea element and set the value from ViewData.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static TextArea TextArea(this IViewDataContainer view, string name)
		{
			return new TextArea(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'checkbox' and set checked from ViewData based on the name provided.
		/// The checkbox element has an accompanying input element of type 'hidden' to support binding upon form post.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static CheckBox CheckBox(this IViewDataContainer view, string name)
		{
			var checkbox = new CheckBox(name, null, view.GetBehaviors()).Value(true);
			var chkd = view.ViewData.Eval(name) as bool?;
			if (chkd.HasValue)
			{
				checkbox.Checked(chkd.Value);
			}
			return checkbox;
		}

		/// <summary>
		/// Generate a list of HTML input elements of type 'checkbox' and set its value from the ViewModel based on the expression provided.
		/// Each checkbox element has an accompanying input element of type 'hidden' to support binding upon form post.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static CheckBoxList CheckBoxList(this IViewDataContainer view, string name)
		{
			return new CheckBoxList(name, null, view.GetBehaviors()).Selected(view.ViewData.Eval(name) as IEnumerable);
		}

		/// <summary>
		/// Generate an HTML input element of type 'submit.'
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="text">Value of the 'value' and 'name' attributes.  Also used to derive the 'id' attribute.</param>
		public static SubmitButton SubmitButton(this IViewDataContainer view, string text)
		{
			return new SubmitButton(text, view.GetBehaviors());
		}

		/// <summary>
		/// Generate an HTML input element of type 'button.'
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="text">Value of the 'value' and 'name' attributes.  Also used to derive the 'id' attribute.</param>
		public static Button Button(this IViewDataContainer view, string text)
		{
			return new Button(text, view.GetBehaviors());
		}

		/// <summary>
		/// Generate an HTML input element of type 'reset.'
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="text">Value of the 'value' and 'name' attributes.  Also used to derive the 'id' attribute.</param>
		public static ResetButton ResetButton(this IViewDataContainer view, string text)
		{
			return new ResetButton(text, view.GetBehaviors());
		}

		/// <summary>
		/// Generate an HTML label element;
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="forName">The id of the target element to point to in the 'for' attribute.</param>
		public static Label Label(this IViewDataContainer view, string forName)
		{
			return new Label(forName, null, view.GetBehaviors()).Value(view.ViewData.Eval(forName));
		}

		/// <summary>
		/// Generate an HTML span element.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="value">The inner text.</param>
		public static Literal Literal(this IViewDataContainer view, object value)
		{
			return view.Literal("", value);
		}

		/// <summary>
		/// Generate an HTML span element.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">The name of the element.</param>
		/// <param name="value">The inner text.</param>
		public static Literal Literal(this IViewDataContainer view, string name, object value)
		{
			return new Literal(name, null, view.GetBehaviors()).Value(value);
		}

		/// <summary>
		/// Generate an HTML span element and an HTML input element of type 'hidden' and set the inner text
		/// of the span and the value of the hidden input element from ViewData based on the specified name.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static FormLiteral FormLiteral(this IViewDataContainer view, string name)
		{
			return new FormLiteral(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'file' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static FileUpload FileUpload(this IViewDataContainer view, string name)
		{
			return new FileUpload(name, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'radio.'
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the of the input elements.  Also used to derive the 'id' attributes.</param>
		public static RadioButton RadioButton(this IViewDataContainer view, string name)
		{
			return new RadioButton(name, null, view.GetBehaviors());
		}

		/// <summary>
		/// Generate a set of HTML input elements of type 'radio' -- each wrapped inside a label.  The whole thing is wrapped in an HTML 
		/// div element.  The values of the input elements and he label text are taken from the options specified.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the of the input elements.  Also used to derive the 'id' attributes.</param>
		public static RadioSet RadioSet(this IViewDataContainer view, string name)
		{
			return new RadioSet(name, null, view.GetBehaviors()).Selected(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'number' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static NumberBox NumberBox(this IViewDataContainer view, string name)
		{
			return new NumberBox(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'search' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static SearchBox SearchBox(this IViewDataContainer view, string name)
		{
			return new SearchBox(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'range' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static RangeBox RangeBox(this IViewDataContainer view, string name)
		{
			return new RangeBox(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'tel' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static TelephoneBox TelephoneBox(this IViewDataContainer view, string name)
		{
			return new TelephoneBox(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'date' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static DatePicker DatePicker(this IViewDataContainer view, string name)
		{
			return new DatePicker(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'month' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static MonthPicker MonthPicker(this IViewDataContainer view, string name)
		{
			return new MonthPicker(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'week' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static WeekPicker WeekPicker(this IViewDataContainer view, string name)
		{
			return new WeekPicker(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'datetime' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static DateTimePicker DateTimePicker(this IViewDataContainer view, string name)
		{
			return new DateTimePicker(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}
		
		/// <summary>
		/// Generate an HTML input element of type 'datetime-local' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static DateTimeLocalPicker DateTimeLocalPicker(this IViewDataContainer view, string name)
		{
			return new DateTimeLocalPicker(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'time' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static TimePicker TimePicker(this IViewDataContainer view, string name)
		{
			return new TimePicker(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'color' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static ColorPicker ColorPicker(this IViewDataContainer view, string name)
		{
			return new ColorPicker(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}

		/// <summary>
		/// Generate an HTML input element of type 'url' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static UrlBox UrlBox(this IViewDataContainer view, string name)
		{
			return new UrlBox(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}
		
		/// <summary>
		/// Generate an HTML input element of type 'url' and set its value from ViewData based on the name provided.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="name">Value of the 'date' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public static EmailBox EmailBox(this IViewDataContainer view, string name)
		{
			return new EmailBox(name, null, view.GetBehaviors()).Value(view.ViewData.Eval(name));
		}
		
		/// <summary>
		/// Generate an HTML datalist element.
		/// </summary>
		/// <param name="view">The view.</param>
		public static DataList DataList(this IViewDataContainer view, string id)
		{
			return new DataList(id, view.GetBehaviors());
		}

		public static IEnumerable<IBehaviorMarker> GetBehaviors(this IViewDataContainer view)
		{
			var behaviorsContainer = view as IBehaviorsContainer;
			return behaviorsContainer == null
				? null
				: behaviorsContainer.Behaviors;
		}
	}
}
