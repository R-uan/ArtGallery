﻿namespace ArtGallery.Controllers;
using ArtGallery.Models;
using ArtGallery.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ArtGallery.Utils;
using ArtGallery.DTO;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("/artwork")]
public class ArtworkController(IArtworkService service) : ControllerBase {
	private readonly IArtworkService _service = service;

	//
	//	Summary:
	//		Lists all the all artworks from the database.
	//	Returns:
	//		200 Status Code with a paginated response that has a list of partial data.
	//		500 Status Code with the error message.
	[HttpGet]
	public async Task<ActionResult<List<Artwork>>> All() {
		try {
			var artwork = await _service.GetAll();
			return Ok(artwork);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
	//
	//	Summary:
	//		Lists all the all artworks that matches the query received.
	//	Returns:
	//		200 Status Code with a paginated response that has a list of partial data.
	//		500 Status Code with the error message.
	[HttpGet("/artwork/q")]
	public async Task<ActionResult<PaginatedResponse<PartialArtworkDTO>>> QuerySearch([FromQuery] ArtworkQueryParams queryParams, [FromQuery] int page = 1) {
		var artists = await _service.PaginatedQuery(queryParams, page);
		return Ok(artists);
	}
	//
	//	Summary:
	//		Lists all the all artworks from the database in a partial format.
	//	Returns:
	//		200 Status Code with a list of entity.
	//		500 Status Code with the error message.
	[HttpGet("partial")]
	public async Task<ActionResult<List<PartialArtworkDTO>>> PartialArtworks() {
		try {
			var artwork = await _service.GetAllPartial();
			return Ok(artwork);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
	//
	//	Summary:
	//		Lists all the all artworks from the database in a partial and paginated format.
	//	Returns:
	//		200 Status Code with a paginated response that has a list of partial entity.
	//		500 Status Code with the error message.
	[HttpGet("partial/paginate")]
	public async Task<ActionResult<PaginatedResponse<PartialArtworkDTO>>> PaginatedPartial([FromQuery] int pageIndex = 1) {
		try {
			var response = await _service.GetAllPartialPaginated(pageIndex);
			return Ok(response);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
	//
	//	Summary:
	//		Finds the record associated with the given SLUG.
	//	Returns:
	//		200 Status Code with the found entity
	// 		404 Status Code
	// 		500 Status Code with the error message.
	[HttpGet("{slug}")]
	public async Task<ActionResult<Artwork>> OneBySlug(string slug) {
		try {
			var artwork = await _service.GetOneBySlug(slug);
			return artwork != null ? Ok(artwork) : NotFound();
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
	//
	//	Summary:
	//		Finds the record associated with the given ID.
	//	Returns:
	//		200 Status Code with the found entity
	// 		404 Status Code
	// 		500 Status Code with the error message.
	[HttpGet("{id:int}")]
	public async Task<ActionResult<Artwork>> OneById(int id) {
		try {
			var artwork = await _service.GetOneById(id);
			return artwork != null ? Ok(artwork) : NotFound();
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
	//
	//	Summary:
	//		Creates a Artwork Record from the data received from the body.
	//	Returns:
	//		200 Status Code and the created entity.
	//		400 Status Code and the validation error message.
	//	 	500 Status Code and the error message.
	[HttpPost]
	[Authorize]
	public async Task<ActionResult<Artwork>> Post([FromBody] ArtworkDTO artwork) {
		try {
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var create_artist = await _service.PostOne(artwork);
			return Ok(create_artist);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
	//
	//	Summary:
	//		Deletes the record related to the ID provided.
	//	Returns:
	//		200 Status Code and a boolean of the value true.
	//		500 Status Code and a boolean of the value false.
	[Authorize]
	[HttpDelete("{id:int}")]
	public async Task<ActionResult<bool>> Delete(int id) {
		try {
			var delete = await _service.DeleteOne(id);
			return delete == null ? NotFound(false) : Ok(true);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
	//
	//	Summary:
	//		Update the record related to the ID with the data received from the body.
	//	Returns:
	//		200 Status Code and the updated entity.
	//		500 Status Code with error message.
	[Authorize]
	[HttpPatch("{id:int}")]
	public async Task<ActionResult<Artwork>> Patch(int id, [FromBody] UpdateArtworkDTO artwork) {
		try {
			var update = await _service.UpdateOne(id, artwork);
			if (update == null) return NotFound();
			return Ok(update);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}
}

