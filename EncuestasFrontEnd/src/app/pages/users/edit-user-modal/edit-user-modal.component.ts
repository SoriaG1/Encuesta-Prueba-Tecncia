import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PutUser } from '../../../core/interfaces/user';
import { AccountService } from '../../../core/serivices/account.service';

@Component({
  selector: 'app-edit-user-modal',
  templateUrl: './edit-user-modal.component.html',
  styleUrl: './edit-user-modal.component.scss'
})
export class EditUserModalComponent {
  constructor(private accountService: AccountService, public dialogRef: MatDialogRef<EditUserModalComponent>, @Inject(MAT_DIALOG_DATA) public data: { user: PutUser }) { }

  onCloseClick(): void {
    this.dialogRef.close();
  }

  putUser() {
    const { id, firstName, lastName, username, password } = this.data.user;
    const updatedUser = {
      id,
      firstName,
      lastName,
      username,
      password  
    };

    this.accountService.putUser(updatedUser).subscribe(
      (response) => {
        console.log('Ok', response);
        this.dialogRef.close();
      },
      (error) => {
        console.error('Error', error);
      }
    );
  }
}
