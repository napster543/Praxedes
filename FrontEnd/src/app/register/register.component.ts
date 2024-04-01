import { ChangeDetectionStrategy, ChangeDetectorRef, Component,  OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Router } from '@angular/router';



import { ToastrService } from 'ngx-toastr';

import { LoginService } from 'src/app/service/login.service';
import { GeneralBaseComponent } from 'src/app/shared/components/base.component';
import { UsuarioDto } from '../interface/usuario/usuario-dto';
import { takeUntil } from 'rxjs';
import { response } from '../interface/response';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush  
})
export class RegistroComponent extends GeneralBaseComponent implements OnInit {

  public loading = false;
  
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
      email: [null, [Validators.required, Validators.pattern('[0-9]*')]],
      pass: [null,  [Validators.required]  ],
      nombre: [null,  [Validators.required]]
  });
  }
 
    
 
  Registrar():void{
    const model: UsuarioDto = this.formGroup.getRawValue();
    this._service.RegistrarUsuario(model)
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe((response: response)=>{
      if(response.Status){
        this.toastr.error(response.Message, "Ok", {timeOut:3000});
      }else{
        this.toastr.error(response.Message, "Error", {timeOut:3000});
      }
      console.log(response);
    }).add(()=>{
      this._changeDetectorRef.markForCheck();
    });	 
	}

 
}


/* fin */
