using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour {
    public Object dialogFile;
    [SerializeField] TMP_Text dialogField;
    [SerializeField] TMP_Text nameField;
    List<Dialog_t> dialogs = new List<Dialog_t>();
    int dialogIndex = 0;
    
    void Start() {
        Dialog.LoadDialogsFromFile(dialogFile.name, ref dialogs);
        Debug.Log("Load - " + dialogs.Count + " dialogs");
    }

    public void UpdateText(Dialog_t dialog) { 
        nameField.text = dialog.author;
        dialogField.text = dialog.text[0];
    }

    public void ResetDialog() { // TODO: refactor this
        dialogIndex = 0;
        dialogField.gameObject.SetActive(true);
        nameField.gameObject.SetActive(true);
        ShowNextDialog();
    }

    public void ShowNextDialog() { // TODO: refactor this
        if(dialogIndex < dialogs.Count)
            UpdateText(dialogs[dialogIndex++]);
        else {
            dialogField.gameObject.SetActive(false);
            nameField.gameObject.SetActive(false);
        }
    }


}
