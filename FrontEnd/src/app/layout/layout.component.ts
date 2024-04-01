import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

import { Router } from '@angular/router';



import { ToastrService } from 'ngx-toastr';

import { LoginService } from 'src/app/service/login.service';
import { GeneralBaseComponent } from 'src/app/shared/components/base.component';



@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush  
})
export class LayoutComponent extends GeneralBaseComponent  {
  @ViewChild('sidenav') public sidenav: MatSidenav;
  showFiller = false;  

  constructor(
    private _service: LoginService,

    private _changeDetectorRef: ChangeDetectorRef,
    private _router: Router,
    private toastr: ToastrService,
    
  ){
    super();
  }
  ngOnInit() { 

   } 
  
}


/* fin */
