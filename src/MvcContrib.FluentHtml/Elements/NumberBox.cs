using System.Collections.Generic;
using System.Linq.Expressions;
using MvcContrib.FluentHtml.Behaviors;

namespace MvcContrib.FluentHtml.Elements
{
	/// <summary>
	/// Generate an HTML input element of type 'number.'
	/// </summary>
	public class NumberBox : NumberBoxBase<NumberBox>
	{
		/// <summary>
		/// Generate an HTML input element of type 'number.'
		/// </summary>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public NumberBox(string name) : base(name) { }

		/// <summary>
		/// Generate an HTML input element of type 'number.'
		/// </summary>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		/// <param name="forMember">Expression indicating the view model member assocaited with the element</param>
		/// <param name="behaviors">Behaviors to apply to the element</param>
		public NumberBox(string name, MemberExpression forMember, IEnumerable<IBehaviorMarker> behaviors)
			: base(name, forMember, behaviors) { }
	}
}