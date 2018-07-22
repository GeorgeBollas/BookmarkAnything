import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';

export interface EditListDialogData {
  name: string;
}

@Component({
  selector: 'app-edit-list-dialog-component',
  templateUrl: './edit-list-dialog.component.html'
})
export class EditListDialogComponent {

  nameFormControl = new FormControl('', [Validators.required]);

  constructor(
    public dialogRef: MatDialogRef<EditListDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EditListDialogData) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
