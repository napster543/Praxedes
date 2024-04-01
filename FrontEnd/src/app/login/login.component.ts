import {AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Router } from '@angular/router';



import { ToastrService } from 'ngx-toastr';
import { takeUntil } from 'rxjs';

import { response } from 'src/app/interface/response';
import { LoginService } from 'src/app/service/login.service';
import { GeneralBaseComponent } from 'src/app/shared/components/base.component';
import { Usuario } from '../interface/usuario/usuario';
import { UsuarioResponse } from '../interface/usuario/usuario-response';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush  
})
export class LoginComponent extends GeneralBaseComponent implements OnInit, OnDestroy {
  public formGroup: FormGroup;

  constructor(
    private _service: LoginService,
    private _changeDetectorRef: ChangeDetectorRef,
    private _router: Router,
    private toastr: ToastrService,
    private _formBuilder: FormBuilder    
  ){
    super();
  }

  ngOnInit() : void{
    this.formGroup = this._formBuilder.group({        
      email: [null, [Validators.required]],
      password: [null,  [Validators.required]  ],
      
  });
  }

  
  Loguear():void{
    const model: Usuario = this.formGroup.getRawValue();
    this._service.GetUsuarioLogin(model)
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe((response: UsuarioResponse)=>{
      if(response.success){
        this.toastr.error(response.message, "Ok", {timeOut:3000});
      }else{
        this.toastr.error(response.message, "Error", {timeOut:3000});
      }
      this._router.navigate(["/admin"]);  
      console.log(response);
    }).add(()=>{
      this._changeDetectorRef.markForCheck();
    });	 
	}

}


/* fin */
