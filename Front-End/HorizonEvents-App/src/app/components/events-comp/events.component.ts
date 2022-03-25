import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventService } from '../../services/event.service';
import { Event } from '../../models/Event';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public events: any = [];
  public filteredEvents: any = [];
  public widthImg: number = 150;
  public heightImg: number = 80;
  public marginImg: number = 2;
  public showImage : boolean = true;
  private _listFilter : string = '';

  public get listFilter() {
    return this._listFilter;
  }

  public set listFilter(value: string){
    this._listFilter = value;
    this.filteredEvents = this.listFilter ? this.filterEvents(this.listFilter) : this.events;
  }

  public filterEvents(filterBy: string) : Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: { theme: string; local: string}) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      event.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  constructor(private eventService: EventService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService
             ) { }

  public ngOnInit() {
    this.getEvents();
    /** spinner starts on init */
    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 3000);
  }

  public changeImage(){
    this.showImage = !this.showImage;
  }

  public getEvents(): void {
    this.eventService.getEvents().subscribe(
      (response) => {
        this.events = response,
        this.filteredEvents = this.events
      },
      error => console.log(error)
    )
  }

  //Modal
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('The Event was successfully deleted', 'Deleted');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
