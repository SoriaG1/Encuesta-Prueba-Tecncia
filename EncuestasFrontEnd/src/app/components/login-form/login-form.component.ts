import { Component, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss'
})

export class LoginFormComponent implements OnInit, OnChanges{

  @Input() isSignUp!: boolean;
  @Output() responseForm: EventEmitter<any> = new EventEmitter();
  
  formUser!: FormGroup;
  defaultFields = {
    username: new FormControl('', Validators.required), 
    password: new FormControl('', Validators.required)
  };

  extraFields = {
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
  };

  constructor(private formBuilder: FormBuilder){
    
  }
  ngOnChanges(changes: SimpleChanges): void {
    this.initForm();
  }

  initForm() {
    let userFields = { ...this.defaultFields };

    if (this.isSignUp) {
      userFields = {...this.defaultFields, ...this.extraFields};
    }
    this.formUser = this.formBuilder.group(userFields);
  }
  

  ngOnInit(): void {
    console.log('LoginForm component initialized.');
  }

  onSubmitForm(){
    this.responseForm.emit(this.formUser.value);
  }

}
