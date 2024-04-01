import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListarEpisodiosComponent } from './listar-episodios/listar-episodios.component';
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
import { MatCardModule } from '@angular/material/card';






@NgModule({
  declarations: [
    ListarEpisodiosComponent,    
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    FormsModule, 
    MatFormFieldModule,
    MatInputModule,      
  ],  
  exports:[
    ListarEpisodiosComponent,

  ]
})
export class ModulosModule { }
