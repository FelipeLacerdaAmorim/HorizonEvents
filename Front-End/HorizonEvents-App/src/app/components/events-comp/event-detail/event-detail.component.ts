import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EventService } from 'app/services/event.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent implements OnInit {

  form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation() : void {
    this.form = this.fb.group({
      theme: ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      eventDate: ['', Validators.required],
      numPeople: ['', [Validators.required, Validators.max(120000)]],
      imageURL: ['', Validators.required],
      telephone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  public resetForm(): void {
    this.form.reset();
  }
}
