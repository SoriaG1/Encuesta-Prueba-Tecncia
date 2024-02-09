import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteUser, PutUser, User } from '../../core/interfaces/user';
import { AccountService } from '../../core/serivices/account.service';
import { MatDialog } from '@angular/material/dialog';
import { EditUserModalComponent } from './edit-user-modal/edit-user-modal.component';
import { DeleteUserModalComponent } from './delete-user-modal/delete-user-modal.component';
import { AddUserModalComponent } from './add-user-modal/add-user-modal.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})
export class UsersComponent implements OnInit{
  
  displayedColumns: string[] = [
    'username',
    'firstName',
    'lastName',
    'role',
    'edit',
    'delete'
  ];
  dataSource!: MatTableDataSource<User>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  display: string = 'none';

  constructor(private accountService: AccountService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.accountService.getUsers().subscribe((response) => {
      const usersArray = Array.isArray(response.model)
        ? response.model
        : [response.model];

      this.dataSource = new MatTableDataSource(usersArray);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openModal(row: User) {
    this.display = 'block';
  }
  onCloseHandled() {
    this.display = 'none';
  }
  
  addUser(){
    const dialogRef = this.dialog.open(AddUserModalComponent);
  
    dialogRef.afterClosed().subscribe(result => {
      console.log('Modal closed, result:', result);
    });
  }

  editUser(user: PutUser) {
    const dialogRef = this.dialog.open(EditUserModalComponent, {
      data: { user } 
    });
  
    dialogRef.afterClosed().subscribe(result => {
      console.log('Modal closed, result:', result);
    });
  }

  deleteUser(user: DeleteUser) {
      const dialogRef = this.dialog.open(DeleteUserModalComponent, {
      data: { user } 
    });
  
    dialogRef.afterClosed().subscribe(result => {
      console.log('Modal closed, result:', result);
    });
  }
}
