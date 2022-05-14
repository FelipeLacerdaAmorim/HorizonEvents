import { Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  formRegister!: FormGroup;

  get fr(): any {
    return this.formRegister.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.regisValidation();
  }

  public regisValidation() : void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'passwordconfirm')
    };

    this.formRegister = this.fb.group({
      firstname: ['',Validators.required],
      lastname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      user: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      passwordconfirm: ['', Validators.required],
    }, formOptions);
  }
}
