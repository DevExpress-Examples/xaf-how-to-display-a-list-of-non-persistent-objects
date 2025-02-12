using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System.Collections;

namespace NonPersistentListView.Module {
    public class ShowDuplicateBooksController : ObjectViewController<ListView, Book> {
        public ShowDuplicateBooksController() {
            PopupWindowShowAction showDuplicatesAction = new PopupWindowShowAction(this, "ShowDuplicateBooks", PredefinedCategory.View);
            showDuplicatesAction.CustomizePopupWindowParams += showDuplicatesAction_CustomizePopupWindowParams;
        }
        private void showDuplicatesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            var duplicatesDictionary = GetDuplicatesDictionary();

            var nonPersistentObjectSpace = Application.CreateObjectSpace(typeof(DuplicatesList));

            var duplicatesList = CreateDuplicatesList(duplicatesDictionary, nonPersistentObjectSpace);

            e.View = Application.CreateDetailView(nonPersistentObjectSpace, duplicatesList);
            e.DialogController.SaveOnAccept = false;
            e.DialogController.CancelAction.Active["NothingToCancel"] = false;
        }
        private Dictionary<string, int> GetDuplicatesDictionary() {
            var dictionary = new Dictionary<string, int>();
            foreach(Book book in View.CollectionSource.List) {
                if(string.IsNullOrWhiteSpace(book.Title)) continue;

                if(dictionary.TryGetValue(book.Title, out int count)) {
                    dictionary[book.Title] = count + 1;
                } else {
                    dictionary[book.Title] = 1;
                }
            }
            return dictionary;
        }
        private DuplicatesList CreateDuplicatesList(Dictionary<string, int> duplicatesDictionary, IObjectSpace nonPersistentObjectSpace) {
            DuplicatesList duplicatesList = nonPersistentObjectSpace.CreateObject<DuplicatesList>();
            foreach(var (title, count) in duplicatesDictionary) {
                if(count <= 1) continue;

                var duplicate = nonPersistentObjectSpace.CreateObject<Duplicate>();
                duplicate.Title = title;
                duplicate.Count = count;

                duplicatesList.Duplicates.Add(duplicate);
            }
            nonPersistentObjectSpace.CommitChanges();
            return duplicatesList;
        }
    }
}
