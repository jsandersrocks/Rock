﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Rock.Data;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// The data access/service class for the <see cref="Rock.Model.History"/> entity. This inherits from the Service class
    /// </summary>
    public partial class HistoryService
    {
        /// <summary>
        /// Adds the changes.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        [Obsolete]
        public static void AddChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<string> changes, int? modifiedByPersonAliasId = null )
        {
            AddChanges( rockContext, modelType, categoryGuid, entityId, changes, null, null, null, modifiedByPersonAliasId );
        }

        /// <summary>
        /// Adds the changes.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        public static void AddChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<History.HistoryChange> changes, int? modifiedByPersonAliasId = null )
        {
            AddChanges( rockContext, modelType, categoryGuid, entityId, changes, null, null, null, modifiedByPersonAliasId );
        }

        /// <summary>
        /// Adds the changes.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="relatedModelType">Type of the related model.</param>
        /// <param name="relatedEntityId">The related entity identifier.</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        [Obsolete]
        public static void AddChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<string> changes, string caption, Type relatedModelType, int? relatedEntityId, int? modifiedByPersonAliasId = null )
        {
            var historyChanges = changes.Select( a => new History.HistoryChange( a ) ).ToList();
            AddChanges( rockContext, modelType, categoryGuid, entityId, historyChanges, caption, relatedModelType, relatedEntityId, modifiedByPersonAliasId );
        }

        /// <summary>
        /// Adds the changes.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="relatedModelType">Type of the related model.</param>
        /// <param name="relatedEntityId">The related entity identifier.</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        public static void AddChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<History.HistoryChange> changes, string caption, Type relatedModelType, int? relatedEntityId, int? modifiedByPersonAliasId = null )
        {
            var entityType = EntityTypeCache.Read( modelType );
            var category = CategoryCache.Read( categoryGuid );
            var creationDate = RockDateTime.Now;

            int? relatedEntityTypeId = null;
            if ( relatedModelType != null )
            {
                var relatedEntityType = EntityTypeCache.Read( relatedModelType );
                if ( relatedModelType != null )
                {
                    relatedEntityTypeId = relatedEntityType.Id;
                }
            }

            if ( entityType != null && category != null )
            {
                var historyService = new HistoryService( rockContext );

                foreach ( var historyChange in changes.Where( m => m != null ) )
                {
                    var history = new History();
                    history.EntityTypeId = entityType.Id;
                    history.CategoryId = category.Id;
                    history.EntityId = entityId;
                    history.Caption = caption.Truncate(200);
                    
                    // for backwards compability, still store summary (and we can ignore the Obsolete warning here)
#pragma warning disable 612, 618
                    history.Summary = historyChange.Summary;
#pragma warning restore 612, 618

                    history.RelatedEntityTypeId = relatedEntityTypeId;
                    history.RelatedEntityId = relatedEntityId;
                    history.Verb = historyChange.Verb;
                    history.ChangeType = historyChange.ChangeType;
                    history.ValueName = historyChange.ValueName.Truncate( 250 );
                    history.SourceOfChange = historyChange.SourceOfChange;
                    history.IsSensitive = historyChange.IsSensitive;

                    if ( modifiedByPersonAliasId.HasValue )
                    {
                        history.CreatedByPersonAliasId = modifiedByPersonAliasId;
                    }

                    // Manually set creation date on these history items so that they will be grouped together
                    history.CreatedDateTime = creationDate;

                    historyService.Add( history );
                }
            }
        }

        /// <summary>
        /// Saves a list of history messages.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="commitSave">if set to <c>true</c> [commit save].</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        [Obsolete]
        public static void SaveChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<string> changes, bool commitSave = true, int? modifiedByPersonAliasId = null )
        {
            SaveChanges( rockContext, modelType, categoryGuid, entityId, changes, null, null, null, commitSave, modifiedByPersonAliasId );
        }

        /// <summary>
        /// Saves a list of history messages.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="commitSave">if set to <c>true</c> [commit save].</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        public static void SaveChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<History.HistoryChange> changes, bool commitSave = true, int? modifiedByPersonAliasId = null )
        {
            SaveChanges( rockContext, modelType, categoryGuid, entityId, changes, null, null, null, commitSave, modifiedByPersonAliasId );
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="relatedModelType">Type of the related model.</param>
        /// <param name="relatedEntityId">The related entity identifier.</param>
        /// <param name="commitSave">if set to <c>true</c> [commit save].</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        [Obsolete]
        public static void SaveChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<string> changes, string caption, Type relatedModelType, int? relatedEntityId, bool commitSave = true, int? modifiedByPersonAliasId = null )
        {
            if ( changes.Any() )
            {
                AddChanges( rockContext, modelType, categoryGuid, entityId, changes, caption, relatedModelType, relatedEntityId, modifiedByPersonAliasId );
                if ( commitSave )
                {
                    rockContext.SaveChanges();
                }
            }
        }

           /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="categoryGuid">The category unique identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="changes">The changes.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="relatedModelType">Type of the related model.</param>
        /// <param name="relatedEntityId">The related entity identifier.</param>
        /// <param name="commitSave">if set to <c>true</c> [commit save].</param>
        /// <param name="modifiedByPersonAliasId">The modified by person alias identifier.</param>
        public static void SaveChanges( RockContext rockContext, Type modelType, Guid categoryGuid, int entityId, List<History.HistoryChange> changes, string caption, Type relatedModelType, int? relatedEntityId, bool commitSave = true, int? modifiedByPersonAliasId = null )
        {
            if ( changes.Any() )
            {
                AddChanges( rockContext, modelType, categoryGuid, entityId, changes, caption, relatedModelType, relatedEntityId, modifiedByPersonAliasId );
                if ( commitSave )
                {
                    rockContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes any saved history items.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="entityId">The entity identifier.</param>
        public static void DeleteChanges( RockContext rockContext, Type modelType, int entityId )
        {
            var entityType = EntityTypeCache.Read( modelType );
            if ( entityType != null  )
            {
                var historyService = new HistoryService( rockContext );
                foreach( var history in historyService.Queryable()
                    .Where( h => 
                        h.EntityTypeId == entityType.Id &&
                        h.EntityId == entityId ) )
                {
                    historyService.Delete( history );
                }

                rockContext.SaveChanges();
            }

        }
    }
}


