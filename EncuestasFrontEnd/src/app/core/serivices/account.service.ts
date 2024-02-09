import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SwalAlertService } from './swal-alert.service';
import { Observable, catchError, throwError } from 'rxjs';
import { User, PostUser, PutUser, signIn, DeleteUser } from '../interfaces/user';
import { ResponseModel } from '../interfaces/response-model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  urlBase: string = 'https://localhost:44360';
  
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }
  
  constructor(private http:HttpClient, 
    private alerts: SwalAlertService) {
  
  }

  errorHandler(error: HttpErrorResponse){
    let errorMessage = `Error code: ${error.status}`;
    if (error.status == 404) {
      this.alerts.errorAlert('Unknown error, please try again later','Unexpected error');
      errorMessage = `${errorMessage} \n message: ${error.error.message}`;
    }
    if (error.error.hasError && error.status == 200) {
      errorMessage = `message: ${error.error.message}`;
    }
    return throwError(() => new Error(errorMessage));
  }

  getUsers(){
    let url: string = `${this.urlBase}/api/User`;
    return this.http.get<ResponseModel<User>>(url, this.httpOptions).pipe(catchError(this.errorHandler));
  }

  postUser(userData: PostUser){
    let url: string = `${this.urlBase}/api/User`;
    console.log(userData.firstName);
    return this.http.post<ResponseModel<PostUser>>(url, userData, this.httpOptions).pipe(catchError(this.errorHandler));
  }

  putUser(userData: PutUser){
    let url: string = `${this.urlBase}/api/User/${userData.id}`;
    return this.http.put<ResponseModel<PutUser>>(url, userData, this.httpOptions).pipe(catchError(this.errorHandler));
  }

  deleteUser(userData: DeleteUser){
    let url: string = `${this.urlBase}/api/User/${userData.id}`;
    return this.http.delete<ResponseModel<PutUser>>(url, this.httpOptions).pipe(catchError(this.errorHandler));
  }

  SignIn(request:signIn): Observable<ResponseModel<any>>{
    let url: string = `${this.urlBase}/api/account`;
    return this.http.post<ResponseModel<any>>(url, request, this.httpOptions).pipe(catchError(this.errorHandler));
  }

  SignUp(request:PostUser): Observable<ResponseModel<any>>{
    let url: string = `${this.urlBase}/api/user`;
    return this.http.post<ResponseModel<any>>(url, request, this.httpOptions).pipe(catchError(this.errorHandler));
  }
}
