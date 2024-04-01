import {AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Router } from '@angular/router';



import { ToastrService } from 'ngx-toastr';
import { takeUntil } from 'rxjs';
import { Episode } from 'src/app/interface/episode';


import { response } from 'src/app/interface/response';
import { results } from 'src/app/interface/results';
import {  LoginService } from 'src/app/service/login.service';
import { RickyService } from 'src/app/service/rickymartin';
import { GeneralBaseComponent } from 'src/app/shared/components/base.component';


@Component({
  selector: 'app-listar-episodios',
  templateUrl: './listar-episodios.component.html',
  styleUrls: ['./listar-episodios.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush  
})
export class ListarEpisodiosComponent extends GeneralBaseComponent implements OnInit, OnDestroy {

   episodios : any;
  
  constructor(
    private _service: RickyService,
    private _changeDetectorRef: ChangeDetectorRef,
    private _router: Router,
    private toastr: ToastrService,
    
  ){
    super();
  }

  ngOnInit() : void{
   this.Listepisodios();
   
  }

  Listepisodios():void{
    
    this._service.GetEpisodio()
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe((response: Episode)=>{    
      this.episodios = response;
      console.log(response);
    }).add(()=>{
      this._changeDetectorRef.markForCheck();
    });	 
	}
  

}


/* fin */
