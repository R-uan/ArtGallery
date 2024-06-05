﻿namespace ArtGallery.Controllers;
using ArtGallery.Models;
using ArtGallery.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using ArtGallery.Utils;
using ArtGallery.DTO;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[ApiController]
[Route("/artwork")]
public class ArtworkController(IArtworkService service, IValidator<Artwork> validator) : ControllerBase {
	private readonly IArtworkService _service = service;
	private readonly IValidator<Artwork> _validator = validator;

	[HttpGet]
	public async Task<ActionResult<List<Artwork>>> All() {
		try {
			var artwork = await _service.GetAll();
			return Ok(artwork);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}

	[HttpPost]
	public async Task<ActionResult<Artwork>> Post([FromBody] ArtworkDTO artwork) {
		try {
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var create_artist = await _service.PostOne(artwork);
			return create_artist;
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet("/artwork/q")]
	public async Task<ActionResult<List<PartialArtworkDTO>>> QuerySearch([FromQuery] ArtworkQueryParams queryParams, [FromQuery] int page = 1) {
		var artists = await _service.PaginatedQuery(queryParams, page);
		return Ok(artists);
	}

	[HttpGet("partial")]
	public async Task<ActionResult<List<PartialArtworkDTO>>> PartialArtworks() {
		try {
			var artwork = await _service.GetAllPartial();
			return Ok(artwork);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet("partial/paginate")]
	public async Task<ActionResult<PaginatedResponse<PartialArtworkDTO>>> PaginatedPartial([FromQuery] int pageIndex = 1) {
		try {
			var response = await _service.GetAllPartialPaginated(pageIndex);
			return Ok(response);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet("{slug}")]
	public async Task<ActionResult<Artwork>> OneBySlug(string slug) {
		try {
			var artwork = await _service.GetOneBySlug(slug);
			return artwork != null ? Ok(artwork) : NotFound();
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<Artwork>> OneById(int id) {
		try {
			var artwork = await _service.GetOneById(id);
			return artwork != null ? Ok(artwork) : NotFound();
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}

	[HttpDelete("{id:int}")]
	public async Task<ActionResult<bool>> Delete(int id) {
		try {
			var delete = await _service.DeleteOne(id);
			return delete == null ? NotFound(false) : Ok(true);
		} catch (System.Exception e) {
			return StatusCode(500, e.Message);
		}
	}

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

