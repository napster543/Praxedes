import {AfterViewInit, ChangeDetectorRef, Component, OnDestroy, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';


@Component({
  selector: 'general-base',
  template: ''  
})
export class GeneralBaseComponent implements OnDestroy {

  public unsubscribe$ = new Subject<void>();

  constructor(){}

  ngOnDestroy():void{
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  
}
