import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PutUser } from '../../../core/interfaces/user';
import { AccountService } from '../../../core/serivices/account.service';
import { EditUserModalComponent } from '../edit-user-modal/edit-user-modal.component';

@Component({
  selector: 'app-delete-user-modal',
  templateUrl: './delete-user-modal.component.html',
  styleUrl: './delete-user-modal.component.scss'
})
export class DeleteUserModalComponent {
  constructor(private accountService: AccountService, public dialogRef: MatDialogRef<EditUserModalComponent>, @Inject(MAT_DIALOG_DATA) public data: { user: PutUser }) { }

  onCloseClick(): void {
    this.dialogRef.close();
  }

  deleteUser() {
    const { id } = this.data.user;
    const idDeleteUser = {
      id
    };

    this.accountService.deleteUser(idDeleteUser).subscribe(
      (response) => {
        console.log('Ok', response);
        this.dialogRef.close();
        this.refreshPage();
      },
      (error) => {
        console.error('Error', error);
      }
    );
  }

  refreshPage() {
    window.location.reload();
  }
}
