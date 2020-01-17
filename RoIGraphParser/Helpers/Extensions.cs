using System.Text;

namespace RoIGraphParser.Helpers {
	public static class Extensions {
		public static string ObjectToString(this object obj) {
			var props = obj.GetType().GetProperties();
			var sb = new StringBuilder();
			sb.AppendLine(obj.GetType().Name + " - Property: Values");
			
			foreach (var p in props)
				sb.AppendLine(p.Name + ": " + p.GetValue(obj, null));

			return sb.ToString();
		}
	}
}