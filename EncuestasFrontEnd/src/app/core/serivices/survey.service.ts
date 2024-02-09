import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError, catchError } from 'rxjs';
import { ResponseModel } from '../interfaces/response-model';
import { SwalAlertService } from './swal-alert.service';
import { Survey } from '../interfaces/survey';

@Injectable({
  providedIn: 'root'
})
export class SurveyServiceService {

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

  getSurveys(){
    let url: string = `${this.urlBase}/api/Survey`;
    return this.http.get<ResponseModel<Survey>>(url, this.httpOptions).pipe(catchError(this.errorHandler));
  }
}
