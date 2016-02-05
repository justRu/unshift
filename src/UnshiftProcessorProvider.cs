using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;

namespace Unshift
{
    [Export(typeof(IKeyProcessorProvider))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    [Name("UnshiftKeyProcessor")]
    internal sealed class UnshiftProcessorProvider : IKeyProcessorProvider
    {
		[Import]
		public IEditorOperationsFactoryService EditorOperationsProvider;

        public KeyProcessor GetAssociatedProcessor(IWpfTextView wpfTextView)
        {
			var operations = EditorOperationsProvider.GetEditorOperations(wpfTextView);
            return new UnshiftKeyProcessor(operations);
        }
    }
}
