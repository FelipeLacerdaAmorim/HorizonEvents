import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'app/helpers/ValidatorField';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  formProfile!: FormGroup;

  get fp(): any {
    return this.formProfile.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    return this.profilValidation();
  }


  public profilValidation() : void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'passwordconfirm')
    };

    this.formProfile = this.fb.group({
      firstname: ['',Validators.required],
      lastname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      passwordconfirm: ['', Validators.required],
    }, formOptions);
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.formProfile.reset();
  }

}
