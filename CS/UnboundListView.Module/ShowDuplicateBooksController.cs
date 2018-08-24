using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace UnboundListView.Module {
    public class ShowDuplicateBooksController : ObjectViewController<ListView, Book> {
        public ShowDuplicateBooksController() {
            PopupWindowShowAction showDuplicatesAction = 
                new PopupWindowShowAction(this, "ShowDuplicateBooks", "View");
            showDuplicatesAction.CustomizePopupWindowParams += showDuplicatesAction_CustomizePopupWindowParams;
        }

        void showDuplicatesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(Book book in View.CollectionSource.List) {
                if(!string.IsNullOrEmpty(book.Title)) {
                    if(dictionary.ContainsKey(book.Title)) {
                        dictionary[book.Title]++;
                    }
                    else 
                        dictionary.Add(book.Title, 1);
                }
            }
            var nonPersistentOS = Application.CreateObjectSpace(typeof(DuplicatesList));
            DuplicatesList duplicateList =nonPersistentOS.CreateObject<DuplicatesList>();
            int duplicateId = 0;
            foreach(KeyValuePair<string, int> record in dictionary) {
                if (record.Value > 1) {
                    var dup = nonPersistentOS.CreateObject<Duplicate>();
                    dup.Id = duplicateId;
                    dup.Title = record.Key;
                    dup.Count = record.Value;
                    duplicateList.Duplicates.Add(dup);
                    duplicateId++;
                }
            }
            nonPersistentOS.CommitChanges();
            e.View = Application.CreateDetailView(nonPersistentOS, duplicateList);
            e.DialogController.SaveOnAccept = false;
            e.DialogController.CancelAction.Active["NothingToCancel"] = false;
        }
    }
}
