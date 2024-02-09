import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie';
import { SwalAlertService } from '../../core/serivices/swal-alert.service';
import { AccountService } from '../../core/serivices/account.service';
import { signIn } from '../../core/interfaces/user';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss'
})
export class SignInComponent {
  constructor(private login: AccountService, 
    private router:Router, 
    private alerts: SwalAlertService,
    private cookie: CookieService){
  
  }

  respForm(request: signIn){
    this.login.SignIn(request).subscribe(response => {
      if (response.hasError) {
        this.alerts.errorAlert('Wrong password or username', 'Login Error');
      }
      if (response.message === 'Authorized' || response.message === 'Authorized') {
        const session = { ...response.model, hasSession: true };
        let objTemp = btoa(JSON.stringify(session));
        this.cookie.put('session', objTemp);
        this.router.navigate(['/home']);
      }
    });
  }
}
