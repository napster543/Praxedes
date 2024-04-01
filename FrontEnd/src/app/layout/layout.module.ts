import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';

import {MatInputModule} from '@angular/material/input';
import { LayoutComponent } from './layout.component';
import { RouterModule } from '@angular/router';
import { AdminLayoutRoutes } from './layout.routing';
import { ListarEpisodiosComponent } from '../modulos/listar-episodios/listar-episodios.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ModulosModule } from '../modulos/modulos.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatGridListModule,
    MatDividerModule,    
    MatIconModule,
    MatSelectModule,
    FormsModule, 
    MatFormFieldModule,    
    MatButtonModule,
    MatInputModule,  
    RouterModule.forChild(AdminLayoutRoutes),
    ModulosModule
  ]
  
})
export class LayoutModule { }
