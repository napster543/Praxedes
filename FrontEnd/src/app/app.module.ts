import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './guards/auth.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { LayoutComponent } from './layout/layout.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card'; 
import { RegistroComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LayoutModule } from './layout/layout.module';
import { CommonModule } from '@angular/common';
@NgModule({
  
  imports: [
    LayoutModule,        
    SharedModule,
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: false,
    }),
    MatFormFieldModule,
    MatSidenavModule,
    MatButtonModule,
    MatInputModule,  
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    
    
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule  
  ],
  declarations: [
    AppComponent,
    LayoutComponent,
    LoginComponent,
    RegistroComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true
    }
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  bootstrap: [AppComponent],
 
})
export class AppModule { }
