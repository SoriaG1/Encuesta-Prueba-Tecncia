import { Component } from '@angular/core';
import { AccountService } from '../../core/serivices/account.service';
import { PostUser } from '../../core/interfaces/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {
  constructor(private login: AccountService, private router: Router) {}

  respForm(request: PostUser): void {
    this.login.postUser(request).subscribe(
      (response) => {
        if (response.hasError) {
          console.log("Error:", response.message);
        } else {
          console.log('Success:', response);
          this.router.navigate(['/sign-in']);
        }
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }
}