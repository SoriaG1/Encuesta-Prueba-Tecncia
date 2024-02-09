import { Component } from '@angular/core';
import { PostUser } from '../../../core/interfaces/user';
import { MatDialogRef } from '@angular/material/dialog';
import { AccountService } from '../../../core/serivices/account.service';

@Component({
  selector: 'app-add-user-modal',
  templateUrl: './add-user-modal.component.html',
  styleUrl: './add-user-modal.component.scss'
})

export class AddUserModalComponent {
  newUser: PostUser = { firstName: '', lastName: '', username: '', password: '' };

  constructor(private accountService: AccountService, public dialogRef: MatDialogRef<AddUserModalComponent>) {}

  ngOnInit(): void {}

  onCloseClick(): void {
    this.dialogRef.close();
  }

  addUser() {
    console.log(this.newUser.firstName);
    this.accountService.postUser(this.newUser).subscribe(
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
