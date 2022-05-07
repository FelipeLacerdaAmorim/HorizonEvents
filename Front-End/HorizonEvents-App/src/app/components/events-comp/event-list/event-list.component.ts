import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { EventService } from 'app/services/event.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss']
})
export class EventListComponent implements OnInit {



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
              private spinner: NgxSpinnerService,
              private router: Router
             ) { }

  public ngOnInit() {
    this.getEvents();
    /** spinner starts on init */
    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 1 second */
      this.spinner.hide();
    }, 1000);
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

  eventDetail(id: Number): void {
    this.router.navigate([`events/detail/${id}`]);
  }
}
