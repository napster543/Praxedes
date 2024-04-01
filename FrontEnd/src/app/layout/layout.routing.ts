import { Routes } from '@angular/router';
import { ListarEpisodiosComponent } from '../modulos/listar-episodios/listar-episodios.component';
import { AuthGuard } from '../guards/auth.guard';

export const AdminLayoutRoutes: Routes = [    
    { path: 'episodios',      component: ListarEpisodiosComponent },
    
    
];
